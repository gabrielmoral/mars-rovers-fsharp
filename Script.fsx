#load "DomainTypes.fs"
#load "Operations.fs"

open MarsRovers.DomainTypes
open MarsRovers.Operations
let marsRovers = {Position={X=5;Y=5};Heading=N}
let planet = {Positions=[];LimitX=10;LimitY=10}

let planet' = drop marsRovers planet

marsRovers |> moveAround planet' ['R';'R';'F';'F';'F';'F';'F';]
