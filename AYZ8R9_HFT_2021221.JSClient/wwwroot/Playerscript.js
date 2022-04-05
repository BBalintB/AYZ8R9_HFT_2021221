let players = [];
let  connection = null;
gettData();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:49978/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();
    connection.on("PlayerCreated", (user, message) => {
        gettData();
    });

    connection.on("PlayerUpdated", (user, message) => {
        gettData();
    });

    connection.on("PlayerDeleted", (user, message) => {
        gettData();
    });

    connection.onclose(async () => {
        await start();
    });
    start();
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function gettData() {
    await fetch('http://localhost:49978/player')
        .then(x => x.json())
        .then(y => {
            players = y;
            console.log(players);

            display();
        });
}





function display() {
    document.getElementById('resultarea').innerHTML = "";
    players.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.playerId + "</td><td>"
            + t.playerName + "</td><td>"
            + t.playerJerseyNumber + "</td><td>"
            + t.position + "</td><td>"
            + t.age + "</td><td>"
            + t.statID + "</td><td>"
            + t.teamID + "</td><td>"
        + `<button type="button" onclick="remove('${t.playerId}')">Delete</button><button type="button" onclick="update('${t.playerId}')">Update</button>` + "</td></tr>";


    });
}

function remove(id) {
    fetch('http://localhost:49978/player/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            gettData();
        })
        .catch((error) => { console.error('Error:', error);})
    
}

function create() {
    let name = document.getElementById('pName').value;
    let jersey = document.getElementById('pJersey').value;
    let position = document.getElementById('pPosition').value;
    let age = document.getElementById('pAge').value;
    let  statid = document.getElementById('pStatId').value;
    let teamid = document.getElementById('pTeamId').value;
    fetch('http://localhost:49978/player', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                playerName: name,
                playerJerseyNumber: jersey,
                position: position,
                age: age,
                statID: statid,
                teamID:teamid

            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            gettData();
        })
        .catch((error) => {
            console.error('Error:', error);
        })
    
}

function update(id) {
    let name = document.getElementById('pName').value;
    let jersey = document.getElementById('pJersey').value;
    let position = document.getElementById('pPosition').value;
    let age = document.getElementById('pAge').value;
    let statid = document.getElementById('pStatId').value;
    let teamid = document.getElementById('pTeamId').value;
    fetch('http://localhost:49978/player', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                playerId:id,
                playerName: name,
                playerJerseyNumber: jersey,
                position: position,
                age: age,
                statID: statid,
                teamID: teamid
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            gettData();
        })
        .catch((error) => {
            console.error('Error:', error);
        })

}

