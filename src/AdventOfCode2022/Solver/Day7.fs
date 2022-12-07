module AdventOfCode2022.Solver.Day7

type File = { Size: int64 }

type Folder = { Name: string; Files: File list }

type State =
    { FileSystem: Map<string, Folder>
      CurrentPath: string }

let changeDirectory (currentPath: string) (destination: string) =
    if destination = ".." then
        currentPath.Substring(0, currentPath.LastIndexOf '/')
    else
        currentPath + "/" + destination

let addDirectory (state: State) (dirName: string) =
    let path = $"{state.CurrentPath}/{dirName}"

    { state with
        FileSystem =
            state.FileSystem
            |> (Map.add path { Name = path; Files = [] }) }

let addFile (state: State) (fileSize: int64) =
    { state with
        FileSystem =
            state.FileSystem
            |> Map.change state.CurrentPath (fun el ->
                match el with
                | Some folder -> Some { folder with Files = { Size = fileSize } :: folder.Files }
                | None -> None) }

let traverseFileSystem (state: State) (input: string) =
    if input.StartsWith "$ cd " then
        { state with CurrentPath = (changeDirectory state.CurrentPath (input.Substring 5)) }
    elif input.StartsWith "$ ls" then
        state
    elif input.StartsWith "dir" then
        addDirectory state (input.Substring 4)
    else
        addFile state (input.Substring(0, input.IndexOf ' ') |> int64)


let calcDirectorySize (state: State) (folder: Folder) =
    let fileSize =
        (folder.Files |> List.sumBy (fun x -> x.Size))

    let children =
        state.FileSystem
        |> Map.filter (fun key _ -> key.StartsWith(folder.Name + "/"))

    let childrenSize =
        children.Values
        |> Seq.sumBy (fun x -> x.Files |> List.sumBy (fun y -> y.Size))

    fileSize + childrenSize

let getFileSystem lines =
    lines
    |> Array.skip 1
    |> Array.fold
        traverseFileSystem
        { CurrentPath = "/"
          FileSystem = Map [ "/", { Name = "/"; Files = [] } ] }

let getSizes fs =
    fs.FileSystem.Values
    |> Seq.map (calcDirectorySize fs)
    |> List.ofSeq

let solver1 (lines: string array) =
    let fs = getFileSystem lines

    getSizes fs
    |> List.filter (fun x -> x <= 100000)
    |> List.sum

let solver2 (lines: string array) =
    let fs = getFileSystem lines
    let sizes = getSizes fs

    let unusedSpace = 70000000L - (sizes |> List.max)

    sizes
    |> Seq.filter (fun x -> x + unusedSpace > 30000000)
    |> Seq.min
