module AdventOfCode2022.Solver.Day9

open System

type Pos = { X: int; Y: int }

type State =
    { Visited: Set<Pos>
      HeadPosition: Pos
      FollowerPositions: Pos array }

let getDistance (head: Pos) (tail: Pos) =
    let xDistance = Math.Abs(head.X - tail.X)
    let yDistance = Math.Abs(head.Y - tail.Y)
    Math.Max(xDistance, yDistance)

let getNewHeadPosition (instruction: Char) (head: Pos) =
    match instruction with
    | 'R' -> { X = head.X + 1; Y = head.Y }
    | 'L' -> { X = head.X - 1; Y = head.Y }
    | 'U' -> { X = head.X; Y = head.Y + 1 }
    | 'D' -> { X = head.X; Y = head.Y - 1 }
    | _ -> head

let getNewFollowerPosition (head: Pos) (follower: Pos) =
    if (getDistance head follower) < 2 then
        follower
    else if follower.X = head.X then
        { X = follower.X
          Y = follower.Y + 1 * Math.Sign(head.Y - follower.Y) }
    elif follower.Y = head.Y then
        { X = follower.X + 1 * Math.Sign(head.X - follower.X)
          Y = follower.Y }
    else
        { X = follower.X + 1 * Math.Sign(head.X - follower.X)
          Y = follower.Y + 1 * Math.Sign(head.Y - follower.Y) }

let move (state: State) (instruction: Char) =
    let newHeadPosition =
        getNewHeadPosition instruction state.HeadPosition

    let newFollowerPositions =
        Array.init state.FollowerPositions.Length (fun _ -> { X = 0; Y = 0 })

    for i in 0 .. newFollowerPositions.Length - 1 do
        let predecessor =
            if i = 0 then
                newHeadPosition
            else
                newFollowerPositions.[i - 1]

        newFollowerPositions.[i] <- getNewFollowerPosition predecessor state.FollowerPositions[i]

    { HeadPosition = newHeadPosition
      FollowerPositions = newFollowerPositions
      Visited = state.Visited.Add(Array.last newFollowerPositions) }

let commandToInstructions (command: string) =
    let times = (command.Split ' ').[1] |> int
    Array.init times (fun _ -> command.[0])

let getVisitations lines ropeLength =
    let instructions =
        lines
        |> Array.map commandToInstructions
        |> Array.concat

    let result =
        instructions
        |> Array.fold
            move
            { Visited = Set.empty
              HeadPosition = { X = 0; Y = 0 }
              FollowerPositions = Array.init ropeLength (fun _ -> { X = 0; Y = 0 }) }

    result.Visited.Count

let solver1 (lines: string array) = getVisitations lines 1

let solver2 (lines: string array) = getVisitations lines 9
