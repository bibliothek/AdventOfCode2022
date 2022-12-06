module AdventOfCode2022.Solver.Day6

open System
open Microsoft.FSharp.Core

let getFirstOccurenceOfUniqueSequence (lines: string array) count =
    let input = lines[0]

    let uniqueString =
        input.ToCharArray()
        |> Array.windowed count
        |> Array.find (fun x -> x |> Set.ofArray |> Set.count = count)
        |> String

    input.IndexOf uniqueString + count

let solver1 (lines: string array) =
    getFirstOccurenceOfUniqueSequence lines 4


let solver2 (lines: string array) =
    getFirstOccurenceOfUniqueSequence lines 14
