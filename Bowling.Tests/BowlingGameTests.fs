namespace Bowling.Tests

open NUnit.Framework
open FsUnit
open System
open Bowling

module ``Roll Method`` =

  //Test Gutter Game
  type ``When knocking down zero pins``() =
        
    [<Test>]
    member this.``Score Should Be Zero`` () =
        let rolls = []

        let actual = Game.CalculateScore rolls

        actual |> should equal 0

  type ``When knocking down all singles`` () =
    [<Test>]
    member this.``Score Should Be Twenty`` () =

        let rolls =
            [(1,1);(1,1);(1,1);(1,1);(1,1);(1,1);(1,1);(1,1);(1,1);(1,1);]

        let result = Game.CalculateScore rolls

        result |> should equal (20)


  type ``When getting a spare`` () =
    [<Test>]
    member this.``Score Should Be Thirteen`` () =

        let rolls =
            [(5,5);(1,1)]

        let result = Game.CalculateScore rolls

        result |> should equal 13


  type ``When getting a strike`` () =
    [<Test>]
    member this.``Score Should Be Thirty`` () =

        let rolls =
            [(1,1);(1,1);(1,1);(1,1);(10,0);(1,1);(1,1);(1,1);(1,1);(1,1);]

        let result = Game.CalculateScore rolls

        result |> should equal 30

  type ``When getting a turkey`` () =
    [<Test>]
    member this.``Score Should Be Thirty`` () =

        let rolls =
            seq{1..3} |> Seq.map (fun _ -> (10,0)) |> List.ofSeq

        let result = Game.CalculateScore rolls

        result |> should equal 60

  type ``When having a perfect game`` () =
    [<Test>]
    member this.``Score Should Be Three Hundred`` () =

        let rolls = List.append (seq{1..10} |> Seq.map (fun _ -> (10,0)) |> List.ofSeq) [(10,10)]
        
        let result = Game.CalculateScore rolls

        result |> should equal 300