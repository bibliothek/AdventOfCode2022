module AdventOfCode2022.Tests.Day4Tests

open AdventOfCode2022.Solver
open Xunit

type Day4Test() =
    let demoData =
        [| 
            "2-4,6-8"
            "2-3,4-5"
            "5-7,7-9"
            "2-8,3-7"
            "6-6,4-6"
            "2-6,4-8"
            |]

    [<Fact>]
    let ``Day 4 part 1`` () =
        let solution = Day4.solver1 demoData
        Assert.Equal(2, solution)


    [<Fact>]
    let ``Day 4 part 2`` () =
        let solution = Day4.solver2 demoData
        Assert.Equal(4, solution)
