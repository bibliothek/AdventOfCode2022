module AdventOfCode2022.Solver.Day5

open System
open System.Text.RegularExpressions

let getStacks (lines: string array) =
    let stackCount = (lines[0].Length + 1) / 4

    seq {
        for i in 0 .. stackCount - 1 ->
            lines
            |> Array.map (fun x -> x.[((i * 4) + 1)])
            |> Array.filter Char.IsLetter
            |> List.ofArray
    }
    |> Array.ofSeq

let instructionRegex =
    Regex("move (\d+) from (\d+) to (\d+)")

let parseInstruction (line: string) =
    let m = instructionRegex.Match line
    m.Groups[1].Value |> int, m.Groups[2].Value |> int, m.Groups[3].Value |> int

let moveElements (state: char list array) (count: int) (source: int) (destination: int) =
    let elements =
        state.[source - 1] |> List.take count

    state[source - 1] <- state.[source - 1] |> List.skip count
    state[destination - 1] <- elements @ state.[destination - 1]
    state

let processInstruction1 (state: char list array) (instruction: string) =
    let count, source, dest =
        parseInstruction instruction

    for i in 1..count do
        moveElements state 1 source dest |> ignore

    state

let processInstruction2 (state: char list array) (instruction: string) =
    let count, source, dest =
        parseInstruction instruction

    moveElements state count source dest

let getStacksAndInstructions lines =
    let stackLines =
        lines
        |> Array.takeWhile (String.IsNullOrEmpty >> not)

    let instructionLines =
        lines
        |> Array.skipWhile (String.IsNullOrWhiteSpace >> not)
        |> Array.skip 1

    let stacks =
        stackLines
        |> Array.take (stackLines.Length - 1)
        |> getStacks

    stacks, instructionLines

let getResultString result = result |> Array.map List.head |> String

let solver1 (lines: string array) =
    let stacks, instructionLines =
        getStacksAndInstructions lines

    instructionLines
    |> Array.fold processInstruction1 stacks
    |> getResultString


let solver2 (lines: string array) =
    let stacks, instructionLines =
        getStacksAndInstructions lines

    instructionLines
    |> Array.fold processInstruction2 stacks
    |> getResultString
