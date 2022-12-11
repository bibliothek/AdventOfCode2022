module AdventOfCode2022.Solver.Day10

open System

type State =
    { Iteration: int
      SignalStrength: int
      OpenCheckpoints: Set<int>
      RegisteredValues: int list }

let eval (state: State) (instruction: string) =
    let newIteration =
        if instruction = "noop" then
            state.Iteration + 1
        else
            state.Iteration + 2

    let newSignalStrength =
        if instruction = "noop" then
            state.SignalStrength
        else
            state.SignalStrength
            + (instruction.Substring 5 |> int)

    let nextCheckpoint =
        if state.OpenCheckpoints.IsEmpty then
            Int32.MaxValue
        else
            state.OpenCheckpoints.MinimumElement

    let newOpenCheckpoints =
        if newIteration >= nextCheckpoint then
            state.OpenCheckpoints
            |> Set.remove state.OpenCheckpoints.MinimumElement
        else
            state.OpenCheckpoints

    let newRegisteredValues =
        if newOpenCheckpoints.Count = state.OpenCheckpoints.Count then
            state.RegisteredValues
        else
            state.SignalStrength * nextCheckpoint
            :: state.RegisteredValues

    { Iteration = newIteration
      SignalStrength = newSignalStrength
      OpenCheckpoints = newOpenCheckpoints
      RegisteredValues = newRegisteredValues }

let solver1 (lines: string array) =
    let checkpoints =
        Set.ofList [ 20
                     60
                     100
                     140
                     180
                     220 ]

    let result =
        lines
        |> Array.fold
            eval
            { Iteration = 0
              SignalStrength = 1
              OpenCheckpoints = checkpoints
              RegisteredValues = [] }

    result.RegisteredValues |> List.sum

let solver2 (lines: string array) = failwith "error"
