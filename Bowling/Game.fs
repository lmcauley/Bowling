namespace Bowling

module Game =

    let sumFrame (a,b) = a+b

    let hasASpare frame = 
        sumFrame frame = 10

    let hasAStrike (a,_) = 
        a = 10

    let sumOfNextTwoRolls frames = 
        match frames with
        | frame1::frame2::rest when frame1 |> hasAStrike -> 
            10 + fst frame2
        | frame1::rest ->
            sumFrame frame1
        | _ -> 0
    
    let nextRoll frames =
        match frames with
        | frame::rest -> fst frame
        | _ -> 0


        //function that returns spare strike or nothing
        // change match structure
        // fsharp active patterns *postit

    let rec CalculateScore frames =
        match frames with
        | [] -> 0
        | frame::rest when frame |> hasAStrike -> 
            10 + sumOfNextTwoRolls rest + CalculateScore rest
        | frame::rest when frame |> hasASpare -> 
            10 + nextRoll rest + CalculateScore rest
        | frame::rest ->
            sumFrame frame + CalculateScore rest
        