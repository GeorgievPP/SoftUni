function loadRepos() {
	const username = document.getElementById('username').value;
	
	const url = `http://api.github.com/users/${username}/repos`;

	//1
	fetch(url)
		.then(response => response.json())
		.then(data => {
			const ulElement = document.getElementById('repos');
			ulElement.innerHTML = '';
			data.forEach(r => {
				const liElement = document.createElement('li');
				liElement.textContent = r.full_name;
				ulElement.appendChild(liElement);
			});
		});
	}

	//2
/*
	const requestPromise = fetch(url);

	console.log(requestPromise);

	requestPromise.then(handleResponse);

	function handleResponse(response) {
		console.log(response);
		const dataPromise = response.json();
		dataPromise.then(handleData);
	}

	function handleData(data) {
		console.log(data);
	}
*/

