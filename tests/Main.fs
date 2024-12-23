module Tests.Main

open Fable.Core

let [<Global>] describe (name: string) (f: unit->unit) = jsNative
let [<Global>] it (msg: string) (f: unit->unit) = jsNative

let run () =
    let tests = [
                    Url.tests
                    OS.tests
                    //Path.tests
                    //Buffer.tests
                    Performance.tests
                    TraceEvents.tests
                ] :> Util.Test seq

    for (moduleName, moduleTests) in tests do
        describe moduleName <| fun () ->
            for (name, tests) in moduleTests do
                describe name <| fun _ ->
                    for (msg, test) in tests do
                        it msg test

run()