module AdventOfCode2022.Tests.Day3Tests

open AdventOfCode2022.Solver
open Xunit

type Day3Test() =
    let demoData =
        [|
            "vJrwpWtwJgWrhcsFMMfFFhFp"
            "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL"
            "PmmdzqPrVvPwwTWBwg"
            "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn"
            "ttgJtRGJQctTZtZT"
            "CrZsJsPPZsGzwwsLwLmpwMDw"
        |]

    [<Fact>]
    let ``Day 3 part 1`` () =
        let solution = Day3.solver1 demoData
        Assert.Equal(157, solution)


    [<Fact>]
    let ``Day 3 part 2`` () =
        let solution = Day3.solver2 demoData
        Assert.Equal(70, solution)
