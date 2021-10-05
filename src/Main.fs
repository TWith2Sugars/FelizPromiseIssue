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
    let incrementClick = React.useCallback(fun _ -> dispatch Increment)
    let decrementClick = React.useCallback(fun _ -> dispatch Decrement)
    let incrementAgainClick = React.useCallback(fun _ -> dispatch IncrementAgain)
    Html.div [
        Html.h1 state.Count
        Html.button [
            prop.text "Increment"
            prop.onClick incrementClick
        ]

        Html.button [
            prop.text "Increment Again"
            prop.onClick incrementAgainClick
        ]

        Html.button [
            prop.text "Decrement"
            prop.onClick decrementClick
        ]
    ]

open Browser.Dom

ReactDOM.render(Counter(), document.getElementById "feliz-app")