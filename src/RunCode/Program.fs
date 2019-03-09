open System.IO
let PS = StartProcess.Processor.StartProcess

[<EntryPoint>]
let main argv =
    let path =
        match argv with
        | [| path |] -> path
        | _ -> DirectoryInfo(".").FullName

    let command =
        """docker run -d --name code-server -p 8888:8443 -v "{path}:/root/project" codercom/code-server code-server --allow-http --no-auth"""
            .Replace("{path}", path)

    PS("docker stop code-server")
    PS("docker rm code-server")
    PS(command)
    0