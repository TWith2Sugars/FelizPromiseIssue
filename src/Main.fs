module Main

open Feliz
open Feliz.UseElmish
open Elmish

type Msg =
    | Increment
    | Decrement
    | IncrementAgain

type State = { Count : int }

let init() = { Count = 0 }, Cmd.none

let update msg state =
    match msg with
    | Increment -> { state with Count = state.Count + 1 }, Cmd.none
    | Decrement -> { state with Count = state.Count - 1 }, Cmd.none
    | IncrementAgain -> { state with Count = state.Count + 1 }, Cmd.ofMsg Increment

[<ReactComponent>]
let Counter() =
    let state, dispatch = React.useElmish(init, update, [| |])
    Html.div [
        Html.h1 state.Count
        Html.button [
            prop.text "Increment"
            prop.onClick (fun _ -> dispatch Increment)
        ]

        Html.button [
            prop.text "Increment Again"
            prop.onClick (fun _ -> dispatch IncrementAgain)
        ]

        Html.button [
            prop.text "Decrement"
            prop.onClick (fun _ -> dispatch Decrement)
        ]
    ]

open Browser.Dom

ReactDOM.render(Counter(), document.getElementById "feliz-app")