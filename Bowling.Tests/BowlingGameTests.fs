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
        let actual = Game.roll 0

        actual |> should equal (0)