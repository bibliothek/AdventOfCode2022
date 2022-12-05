module AdventOfCode2022.Tests.Day5Tests

open AdventOfCode2022.Solver
open Xunit

type Day5Test() =
    let demoData =
        [|
            "    [D]    "    
            "[N] [C]    "    
            "[Z] [M] [P]"
            " 1   2   3 " 
            ""
            "move 1 from 2 to 1"
            "move 3 from 1 to 3"
            "move 2 from 2 to 1"
            "move 1 from 1 to 2"
        |]

    [<Fact>]
    let ``Day 5 part 1`` () =
        let solution = Day5.solver1 demoData
        Assert.Equal("CMZ", solution)


    [<Fact>]
    let ``Day 5 part 2`` () =
        let solution = Day5.solver2 demoData
        Assert.Equal("MCD", solution)
