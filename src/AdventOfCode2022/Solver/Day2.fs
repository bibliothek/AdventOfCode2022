module AdventOfCode2022.Solver.Day2

let getSignValue1 (line: string) =
    let c = line.[2]
    match c with
    | 'X' -> 1
    | 'Y' -> 2
    | 'Z' -> 3
    | _ -> failwith "sign does not exist"

let getGameResult1 (line: string) =
    let a = line.[0]
    let b = line.[2]
    match a, b with
    | 'A', 'X'
    | 'B', 'Y'
    | 'C', 'Z' -> 3
    | 'A', 'Y'
    | 'B', 'Z'
    | 'C', 'X' -> 6
    | 'A', 'Z'
    | 'B', 'X'
    | 'C', 'Y' -> 0
    | _ -> failwith "combination does not exist"

let getSignValue2 (line: string) =
    let a = line.[0]
    let b = line.[2]
    match a, b with
    | 'A', 'Y'
    | 'B', 'X'
    | 'C', 'Z' -> 1
    | 'B', 'Y'
    | 'A', 'Z'
    | 'C', 'X' -> 2
    | 'B', 'Z'
    | 'A', 'X'
    | 'C', 'Y' -> 3
    | _ -> failwith "combination does not exist"

let getGameResult2 (line: string) =
    let c = line.[2]
    match c with
    | 'X' -> 0
    | 'Y' -> 3
    | 'Z' -> 6
    | _ -> failwith "result does not exist"

let solver1 (lines: string array) =
    lines
    |> Array.map (fun el -> (getSignValue1 el) + (getGameResult1 el))
    |> Array.sum

let solver2 (lines: string array) =
    lines
    |> Array.map (fun el -> (getSignValue2 el) + (getGameResult2 el))
    |> Array.sum
