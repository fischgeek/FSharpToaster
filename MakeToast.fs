namespace FSharpToaster

open Microsoft.Toolkit.Uwp.Notifications

module Main = 
        
    let private makeToast title message =
        ToastContentBuilder()
            .AddArgument("action", "main")
            .AddHeader("id", title, "title")
            .AddText(message)

    let infoToast title message = 
        let t = makeToast title message
        t.Show()

    let toastWithCallback title message fn = 
        ToastNotificationManagerCompat.add_OnActivated(fun toastArgs -> 
            //let tArgs = ToastArguments.Parse(toastArgs.Argument)
            //let userInput = toastArgs.UserInput
            //let vals =
            //    userInput.Keys
            //    |> Seq.map (fun key -> key)
            fn()
        )
        let t = makeToast title message
        t.Show()

    let toastWithButtons title message = 
        ToastNotificationManagerCompat.add_OnActivated(fun toastArgs -> 
            //let tArgs = ToastArguments.Parse(toastArgs.Argument)
            let userInput = toastArgs.UserInput
            //let vals =
            //    userInput.Keys
            //    |> Seq.map (fun key -> key)
            //fn vals
            ()
        )


        let t = makeToast title message
        t.AddButton(
            ToastButton()
                .SetContent("Like")
                .AddArgument("action", "like")
                .SetBackgroundActivation()
        ).Show()
        
