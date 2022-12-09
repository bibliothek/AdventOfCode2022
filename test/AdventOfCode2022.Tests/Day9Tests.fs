module AdventOfCode2022.Tests.Day9Tests

open AdventOfCode2022.Solver
open Xunit

type Day9Test() =
    let demoData =
        [| "R 4"
           "U 4"
           "L 3"
           "D 1"
           "R 4"
           "D 1"
           "L 5"
           "R 2" |]

    let demoData2 =
        [| "R 5"
           "U 8"
           "L 8"
           "D 3"
           "R 17"
           "D 10"
           "L 25"
           "U 20" |]

    [<Fact>]
    let ``Day 9 part 1`` () =
        let solution = Day9.solver1 demoData
        Assert.Equal(13, solution)


    [<Fact>]
    let ``Day 9 part 2`` () =
        let solution = Day9.solver2 demoData2
        Assert.Equal(36, solution)
