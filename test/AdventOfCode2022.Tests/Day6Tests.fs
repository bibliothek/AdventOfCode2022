module AdventOfCode2022.Tests.Day6Tests

open AdventOfCode2022.Solver
open Xunit

type Day6Test() =

    [<Theory>]
    [<InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7)>]
    [<InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)>]
    [<InlineData("nppdvjthqldpwncqszvftbrmjlhg", 6)>]
    [<InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)>]
    [<InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)>]
    let ``Day 6 part 1`` (input, result) =
        let solution = Day6.solver1 [|input|]
        Assert.Equal(result, solution)


    [<Theory>]
    [<InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)>]
    [<InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)>]
    [<InlineData("nppdvjthqldpwncqszvftbrmjlhg", 23)>]
    [<InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)>]
    [<InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)>]
    let ``Day 6 part 2`` (input, result) =
        let solution = Day6.solver2 [|input|]
        Assert.Equal(result, solution)
