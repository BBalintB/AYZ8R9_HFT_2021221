let statistics = [];
let  connection = null;
gettData();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:49978/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();
    connection.on("StatisticCreated", (user, message) => {
        gettData();
    });

    connection.on("StatisticUpdated", (user, message) => {
        gettData();
    });

    connection.on("StatisticDeleted", (user, message) => {
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
    await fetch('http://localhost:49978/statistic')
        .then(x => x.json())
        .then(y => {
            statistics = y;
            display();
        });
}





function display() {
    document.getElementById('resultarea').innerHTML = "";
    statistics.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.statId + "</td><td>"
            + t.passingYards + "</td><td>"
            + t.receivingYards + "</td><td>"
            + t.rushingYards + "</td><td>"
            + t.touchdowns + "</td><td>"
        + `<button type="button" onclick="remove('${t.statId}')">Delete</button><button type="button" onclick="update('${t.statId}')">Update</button>` + "</td></tr>";


    });
}

function remove(id) {
    fetch('http://localhost:49978/statistic/' + id, {
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
    let passsingYards = document.getElementById('pYards').value;
    let receivingYards = document.getElementById('reYards').value;
    let rushingYards = document.getElementById('ruYards').value;
    let touchdowns = document.getElementById('tDs').value;
    fetch('http://localhost:49978/statistic', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                passingYards: passsingYards,
                receivingYards: receivingYards,
                rushingYards: rushingYards,
                touchdowns: touchdowns
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
    let passsingYards = document.getElementById('pYards').value;
    let receivingYards = document.getElementById('reYards').value;
    let rushingYards = document.getElementById('ruYards').value;
    let touchdowns = document.getElementById('tDs').value;
    fetch('http://localhost:49978/statistic', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                statId:id,
                passingYards: passsingYards,
                receivingYards: receivingYards,
                rushingYards: rushingYards,
                touchdowns: touchdowns
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

