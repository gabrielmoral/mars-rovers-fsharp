namespace MarsRovers.DomainTypes

type Position = {X:int;Y:int}
type Heading = N|S|E|W
type Turn = R|L
type Mars = {Position:Position;Heading:Heading}
type Planet = {Positions:Position list;LimitX:int;LimitY:int}