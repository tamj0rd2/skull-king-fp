namespace SkullKingFp

open System

type CommonSuit =
    | Red
    | Yellow
    | Blue
    | Black

type Rank =
    | One = 1
    | Two = 2
    | Three = 3
    | Four = 4
    | Five = 5
    | Six = 6
    | Seven = 7
    | Eight = 8
    | Nine = 9
    | Ten = 10
    | Eleven = 11
    | Twelve = 12
    | Thirteen = 13

type SpecialSuit =
    | Escape
    | Pirate
    | Mermaid
    | SkullKing
    | ScaryMary

// scary mary can either be played as an escape, or a pirate. not sure if this is the correct way to represent it.
and ScaryMary =
    | Escape
    | Pirate

type RoundNumber =
    | One = 1
    | Two = 2
    | Three = 3
    | Four = 4
    | Five = 5
    | Six = 6
    | Seven = 7
    | Eight = 8
    | Nine = 9
    | Ten = 10

type TrickNumber =
    | One = 1
    | Two = 2
    | Three = 3
    | Four = 4
    | Five = 5
    | Six = 6
    | Seven = 7
    | Eight = 8
    | Nine = 9
    | Ten = 10

type Bid =
    | Zero = 0
    | One = 1
    | Two = 2
    | Three = 3
    | Four = 4
    | Five = 5
    | Six = 6
    | Seven = 7
    | Eight = 8
    | Nine = 9
    | Ten = 10

type Card =
    | RankedCard of CommonSuit * Rank
    | SpecialCard of SpecialSuit

type PlayerId = PlayerId of Guid

type Game =
    { Players: PlayerId list
      RoundNumber: RoundNumber option
      TrickNumber: TrickNumber option
    // and more...
    }

type GameErrorCode =
    | NotEnoughPlayersToCreateGame
    | TooManyPlayersToCreateGame
    | GameIdMismatch
    | CannotPlayMoreThan10Rounds
    | CannotStartAPreviousRound
    | CannotStartARoundMoreThan1Ahead
    | CannotStartARoundThatIsAlreadyInProgress
    | CannotCompleteARoundThatIsNotInProgress
    | CannotBidOutsideBiddingPhase
    | AlreadyBid

type GameResult = Result<Game, GameErrorCode>

type StartRound = Game -> RoundNumber -> GameResult
type StartTrick = Game -> TrickNumber -> GameResult
type PlaceABid = Game -> PlayerId -> Bid -> GameResult
type PlayACard = Game -> PlayerId -> Card -> GameResult
type CompleteTrick = Game -> TrickNumber -> GameResult
type CompleteRound = Game -> RoundNumber -> GameResult
type CompleteGame = Game -> GameResult
