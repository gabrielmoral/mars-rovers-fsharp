namespace MarsRovers

module Operations =
    open MarsRovers.DomainTypes

    let turn command mars =
        match command, mars.Heading with
        |R,N -> {mars with Heading = E}
        |R,E -> {mars with Heading = S}
        |R,S -> {mars with Heading = W}
        |R,W -> {mars with Heading = N}
        |L,N -> {mars with Heading = W}
        |L,E -> {mars with Heading = N}
        |L,S -> {mars with Heading = E}
        |L,W -> {mars with Heading = S}

    let move movement mars =
        let steps = 
            match mars.Heading with
            |N|E -> +1
            |S|W -> -1
        match mars.Heading with
        |N|S -> {mars with Position = {mars.Position with Y = movement mars.Position.Y steps} }
        |E|W -> {mars with Position = {mars.Position with X = movement mars.Position.X steps} }
    let forward = move (+)
    let backward = move (-)

    let parse command =
        match command with
        |'R' -> turn R
        |'L' -> turn L
        |'F' -> forward
        |'B' -> backward

    let processCommand m command =
        parse command m

    let drop mars planet =
        let validDestination = mars.Position.X <= planet.LimitX && mars.Position.Y <= planet.LimitY
        if validDestination then Some {planet with Positions = [mars.Position]}
        else None
        
    let moveAround planet commands mars =
        commands
        |> Seq.fold processCommand mars
