module AdventOfCode2022.Solver.Day8

open AdventOfCode2021

let elementsToTheLeft (map: int[,]) (x:int) (y:int) =
    seq {for i in 0..(x-1) do yield map.[i,y] }
let elementsToTheRight (map: int[,]) (x:int) (y:int) =
    let xMax = (Array2D.length1 map) - 1
    seq {for i in (x+1)..(xMax) do yield map.[i,y] }
    
let elementsAbove (map: int[,]) (x:int) (y:int) =
    seq {for i in 0..(y-1) do yield map.[x,i] }

let elementsBelow (map: int[,]) (x:int) (y:int) =
    let yMax = (Array2D.length2 map) - 1
    seq {for i in (y+1)..(yMax) do yield map.[x,i] }

let isVisible (map: int[,]) (x:int) (y:int) (el: int) =
    let xMax = (Array2D.length1 map) - 1
    let yMax = (Array2D.length2 map) - 1
    match x,y,el with
    | x,y,_ when x = 0 || y = 0 || x = xMax || y = yMax -> true
    | x,y,el ->
        (elementsToTheLeft map x y |> Seq.max) < el
        || (elementsToTheRight map x y |> Seq.max) < el
        || (elementsAbove map x y |> Seq.max) < el
        || (elementsBelow map x y |> Seq.max) < el

let getTreesInViewCount seq el =
    let l = Seq.length seq
    if l = 0 then 0
    else
        let viewableTreesCount = (seq |> Seq.takeWhile (fun x -> x < el) |> Seq.length)
        if viewableTreesCount = l then viewableTreesCount else viewableTreesCount + 1

let scenicScore (map: int[,]) (x:int) (y:int) (el: int) =
    let leftElementsCount = getTreesInViewCount (elementsToTheLeft map x y |> Seq.rev) el
    let rightElementsCount = getTreesInViewCount (elementsToTheRight map x y) el
    let aboveElementsCount = getTreesInViewCount (elementsAbove map x y |> Seq.rev) el
    let belowElementsCount = getTreesInViewCount (elementsBelow map x y) el
    leftElementsCount * rightElementsCount * aboveElementsCount * belowElementsCount
    
let solver1 (lines: string array) =
    let map = Array2DHelper.buildFromLines lines
    let visible = map |> Array2D.mapi (isVisible map)
    visible |> Array2DHelper.toSeq |> Seq.filter id |> Seq.length
    
let solver2 (lines: string array) =
    let map = Array2DHelper.buildFromLines lines
    let scenicScores = map |> Array2D.mapi (scenicScore map)
    scenicScores |> Array2DHelper.toSeq |> Seq.max
