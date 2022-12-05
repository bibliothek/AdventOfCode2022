module AdventOfCode2022.Solver.Day4


let getRange(assignment: string) =
    let split = assignment.Split '-'
    let start = split.[0] |> int
    let ending = split.[1] |> int
    seq { for i in start .. ending -> i } |> Set.ofSeq

let doRangesOverlapCompletely(line: string) =  
    let split = line.Split ','
    let a = split.[0] |> getRange
    let b = split.[1] |> getRange
    let intersection = Set.intersect a b
    intersection.Count = a.Count || intersection.Count = b.Count

let doRangesOverlapPartly(line: string) =  
    let split = line.Split ','
    let a = split.[0] |> getRange
    let b = split.[1] |> getRange
    let intersection = Set.intersect a b
    intersection.Count > 0
    
let solver1 (lines: string array) =
    lines |> Array.map doRangesOverlapCompletely |> Array.filter id |> Array.length

let solver2 (lines: string array) =
    lines |> Array.map doRangesOverlapPartly |> Array.filter id |> Array.length