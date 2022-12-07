module AdventOfCode2022.Tests.Day7Tests

open AdventOfCode2022.Solver
open Xunit

type Day7Test() =
    let demoData =
        [|
            "$ cd /"
            "$ ls"
            "dir a"
            "14848514 b.txt"
            "8504156 c.dat"
            "dir d"
            "$ cd a"
            "$ ls"
            "dir e"
            "29116 f"
            "2557 g"
            "62596 h.lst"
            "$ cd e"
            "$ ls"
            "584 i"
            "$ cd .."
            "$ cd .."
            "$ cd d"
            "$ ls"
            "4060174 j"
            "8033020 d.log"
            "5626152 d.ext"
            "7214296 k"
        |]

    [<Fact>]
    let ``Day 7 part 1`` () =
        let solution = Day7.solver1 demoData
        Assert.Equal(95437L, solution)


    [<Fact>]
    let ``Day 7 part 2`` () =
        let solution = Day7.solver2 demoData
        Assert.Equal(24933642L, solution)
