module AdventOfCode2022.Tests.Day8Tests

open AdventOfCode2022.Solver
open Xunit

type Day8Test() =
    let demoData =
        [| "30373"
           "25512"
           "65332"
           "33549"
           "35390" |]

    [<Fact>]
    let ``Day 8 part 1`` () =
        let solution = Day8.solver1 demoData
        Assert.Equal(21, solution)


    [<Fact>]
    let ``Day 8 part 2`` () =
        let solution = Day8.solver2 demoData
        Assert.Equal(8, solution)
