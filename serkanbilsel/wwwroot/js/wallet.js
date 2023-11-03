
/*let connectedAddress = null;*/

// Array to store transactions
const transactionsArray = [];

// Function to connect to the wallet
const connectWallet = async () => {
    if (window.ethereum) {
        try {
            const accounts = await window.ethereum.request({ method: "eth_requestAccounts" });
            if (accounts.length > 0) {
                connectedAddress = accounts[0];
                document.getElementById("walletAddress").textContent = connectedAddress;
                updateEthBalance();
            } else {
                document.getElementById("walletAddress").textContent = "No connected wallet address";
            }
        } catch (error) {
            document.getElementById("walletAddress").textContent = "Error connecting to wallet: " + error;
        }
    } else {
        document.getElementById("walletAddress").textContent = "No wallet";
    }
};


// Function to update ETH balance for the connected wallet
const updateEthBalance = async () => {
    if (!connectedAddress) {
        return;
    }

    const web3 = new Web3(window.ethereum);
    const balance = await web3.eth.getBalance(connectedAddress);
    const etherBalance = web3.utils.fromWei(balance, 'ether');
    document.getElementById("ethBalance").textContent = etherBalance;
};

// Function to fetch all transactions for the connected wallet
const fetchAllTransactions = async () => {
    if (!connectedAddress) {
        return;
    }

    const apiKey = '47VVDGK651R29E4E77C3GUN8EAZZGC63Q9'; // APIKEY ETH/

    const url = `https://api.etherscan.io/api?module=account&action=txlist&address=${connectedAddress}&startblock=0&endblock=99999999&sort=asc&apikey=${apiKey}`;

    try {
        const response = await fetch(url);
        if (response.ok) {
            const data = await response.json();
            addTransactionsToTable(data.result);
        }
    } catch (error) {
        console.error("Error fetching transactions: " + error);
    }
};

// Function to add transactions to the table

const addTransactionsToTable = (transactions) => {
    transactionsArray.push(...transactions);
    transactions.sort((a, b) => b.timeStamp - a.timeStamp);
    const transactionList = document.getElementById("transactionList");
    transactionList.innerHTML = "";

    transactions.forEach(transaction => {
        const row = transactionList.insertRow();
        row.insertCell(0).textContent = transaction.hash;
        const input = transaction.input;

        // Örnek fonksiyon tanımlamaları - gerçek fonksiyonlara göre güncelleyin
        const transferFunctionSignature = '0xa9059cbb';
        const claimTokensFunctionSignature = '0xb69d1a08';

        let functionName = 'Unknown'; // Varsayılan olarak "Bilinmeyen" fonksiyon

        if (input.startsWith(transferFunctionSignature)) {
            functionName = 'Transfer';
        } else if (input.startsWith(claimTokensFunctionSignature)) {
            functionName = 'Claim Tokens';
        }

        row.insertCell(1).textContent = functionName;

        row.insertCell(2).textContent = transaction.blockNumber;
        const ageInSeconds = (new Date() / 1000 - transaction.timeStamp).toFixed(2);
        const days = Math.floor(ageInSeconds / (60 * 60 * 24));
        const hours = Math.floor((ageInSeconds % (60 * 60 * 24)) / (60 * 60));
        const formattedAge = `${days} days ${hours} hrs ago`;
        row.insertCell(3).textContent = formattedAge;
        row.insertCell(4).textContent = transaction.from;
        row.insertCell(5).textContent = transaction.to;
        row.insertCell(6).textContent = (parseFloat(transaction.value) / 1e18).toFixed(3) + " ETH";
        row.insertCell(7).textContent = (transaction.gas * transaction.gasPrice / 1e18).toFixed(8) + " ETH";

    });
};

// Function to calculate age in days



const calculateAge = (timestamp) => {
    const currentTime = new Date() / 1000;
    const secondsAgo = currentTime - timestamp;
    const daysAgo = Math.floor(secondsAgo / (60 * 60 * 24));
    const hoursAgo = Math.floor((secondsAgo % (60 * 60 * 24)) / (60 * 60));
    return `${daysAgo} days ${hoursAgo} hrs ago`;
};




// İşlem tarihi " days  hrs ago" olarak gösteriliyor.
const transactionTimestamp = Date.now() / 1000 - (20 * 24 * 60 * 60 + 14 * 60 * 60); 
const formattedAge = calculateAge(transactionTimestamp);
console.log(formattedAge); 


document.getElementById("connectWallet").addEventListener("click", connectWallet);
document.getElementById("fetchAllTransactions").addEventListener("click", fetchAllTransactions);








