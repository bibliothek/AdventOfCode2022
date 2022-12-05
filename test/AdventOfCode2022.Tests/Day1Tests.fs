module AdventOfCode2022.Tests.Day1Tests

open AdventOfCode2022.Solver
open Xunit

type Day1Tests() =
    let demoData =
        [| "1000"
           "2000"
           "3000"
           ""
           "4000"
           ""
           "5000"
           "6000"
           ""
           "7000"
           "8000"
           "9000"
           ""
           "10000"
           |]

    [<Fact>]
    let ``Day 1 part 1`` () =
        let solution = Day1.solver1 demoData
        Assert.Equal("24000", solution)

    [<Fact>]
    let ``Day 1 part 2`` () =
        let solution = Day1.solver2 demoData
        Assert.Equal("45000", solution)
