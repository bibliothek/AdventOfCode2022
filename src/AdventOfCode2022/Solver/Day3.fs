module AdventOfCode2022.Solver.Day3

let findCommonItem (line: string) =
    let halfPoint = line.Length / 2

    let compartment1 =
        line.Substring(0, halfPoint).ToCharArray()
        |> Set.ofArray

    let compartment2 =
        line.Substring(halfPoint).ToCharArray()
        |> Set.ofArray

    let common =
        Set.intersect compartment1 compartment2

    common.MinimumElement

let getItemValue (item: char) =
    let i = int item
    if i > 96 then i - 96 else (i - 64) + 26


let findCommonBadge (groupInventories: string array) =
    let common =
        groupInventories
        |> Array.map (fun x -> x.ToCharArray() |> Set.ofArray)
        |> Set.intersectMany

    common.MinimumElement


let solver1 (lines: string array) =
    lines
    |> Array.map (findCommonItem >> getItemValue)
    |> Array.sum

let solver2 (lines: string array) =
    lines
    |> Array.chunkBySize 3
    |> Array.map (findCommonBadge >> getItemValue)
    |> Array.sum
