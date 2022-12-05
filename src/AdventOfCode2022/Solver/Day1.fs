module AdventOfCode2022.Solver.Day1

let sumInventories =
    Array.fold
        (fun (state: List<int>) el ->
            match el with
            | "" -> 0 :: state
            | num -> (state.Head + (num |> int)) :: state.Tail)
        (0 :: List.empty)

let solver1 (lines: string array) =
    lines |> sumInventories |> List.max

let solver2 (lines: string array) =
    lines
    |> sumInventories
    |> List.sortDescending
    |> List.take 3
    |> List.sum
