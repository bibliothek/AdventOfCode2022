module AdventOfCode2022.Solver.Day10

open System
open AdventOfCode2021

type State =
    { Iteration: int
      SignalStrength: int
      OpenCheckpoints: Set<int>
      RegisteredValues: int list }

type State2 =
    { Iteration: int
      SignalStrength: int
      Display: char[,] }

let getNewIteration currentIteration instruction =
    if instruction = "noop" then
        currentIteration + 1
    else
        currentIteration + 2

let getNewSignalStrength currentSignalStrength instruction =
    if instruction = "noop" then
        currentSignalStrength
    else
        currentSignalStrength + (instruction.Substring 5 |> int)

let eval (state: State) (instruction: string) =
    let newIteration = getNewIteration state.Iteration instruction

    let newSignalStrength = getNewSignalStrength state.SignalStrength instruction

    let nextCheckpoint =
        if state.OpenCheckpoints.IsEmpty then
            Int32.MaxValue
        else
            state.OpenCheckpoints.MinimumElement

    let newOpenCheckpoints =
        if newIteration >= nextCheckpoint then
            state.OpenCheckpoints |> Set.remove state.OpenCheckpoints.MinimumElement
        else
            state.OpenCheckpoints

    let newRegisteredValues =
        if newOpenCheckpoints.Count = state.OpenCheckpoints.Count then
            state.RegisteredValues
        else
            state.SignalStrength * nextCheckpoint :: state.RegisteredValues

    { Iteration = newIteration
      SignalStrength = newSignalStrength
      OpenCheckpoints = newOpenCheckpoints
      RegisteredValues = newRegisteredValues }

let getSpritePosition (register: int) =
    [ register - 1; register; register + 1 ] |> Set.ofList

let getChar (register: int) (iteration: int) =
    let spritePosition = getSpritePosition register
    if spritePosition.Contains(iteration % 40) then '#' else '.'

let drawIteration (display: char[,]) (iteration: int) (register: int) =
    let c = getChar register iteration
    let x = iteration % 40
    let y = iteration / 40
    display[x, y] <- c

let eval2 (state: State2) (instruction: string) =
    let newIteration = getNewIteration state.Iteration instruction

    let newSignalStrength = getNewSignalStrength state.SignalStrength instruction

    drawIteration state.Display state.Iteration state.SignalStrength

    if newIteration = state.Iteration + 2 then
        drawIteration state.Display (newIteration - 1) state.SignalStrength

    { state with
        Iteration = newIteration
        SignalStrength = newSignalStrength }

let solver1 (lines: string array) =
    let checkpoints = Set.ofList [ 20; 60; 100; 140; 180; 220 ]

    let result =
        lines
        |> Array.fold
            eval
            { Iteration = 0
              SignalStrength = 1
              OpenCheckpoints = checkpoints
              RegisteredValues = [] }

    result.RegisteredValues |> List.sum

let solver2 (lines: string array) =
    let result =
        lines
        |> Array.fold
            eval2
            { Iteration = 0
              SignalStrength = 1
              Display = Array2D.init (40) 6 (fun _ _ -> 'X') }

    result.Display |> Array2DHelper.getPrintableOverview
