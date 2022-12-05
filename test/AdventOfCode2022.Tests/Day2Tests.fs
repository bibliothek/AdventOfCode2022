module AdventOfCode2022.Tests.Day2Tests

open AdventOfCode2022.Solver
open Xunit

type Day2Test() =
    let demoData = [| "A Y"; "B X"; "C Z" |]

    [<Fact>]
    let ``Day 2 part 1`` () =
        let solution = Day2.solver1 demoData
        Assert.Equal(15, solution)


    [<Fact>]
    let ``Day 2 part 2`` () =
        let solution = Day2.solver2 demoData
        Assert.Equal(12, solution)
