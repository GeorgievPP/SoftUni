function attachEvents() {
    document.getElementById('submit').addEventListener('click', getWeather);
}
attachEvents();

async function getWeather() {
    const cityCodes = {
        'New York': 'ny',
        'London': 'london',
        'Barcelona': 'barcelona',
    };

    const symbols = {
        'Sunny': '&#x2600',
        'Partly sunny': '&#x26C5',
        'Overcast': '&#x2601',
        'Rain': '&#x2614',
        'Degree': '&#176',
    };

    const currentDiv = document.getElementById('current');
    const upcomingDiv = document.getElementById('upcoming');
    const input = document.getElementById('location');
    const cityName = input.value;
    input.value = '';

    while (currentDiv.children.length >= 1 && upcomingDiv.children.length >= 1) {
        currentDiv.removeChild(currentDiv.lastChild);
        upcomingDiv.removeChild(upcomingDiv.lastChild);
    }

    const code = await getCode(cityName);

    const[current, upcoming] = await Promise.all([
        getCurrent(code),
        getUpcoming(code)
    ]);

    //console.log(current, upcoming);

    document.getElementById('forecast').style.display = 'block';

    const divForecasts = createElement('div', undefined, 'forecasts');
    const conditionSymbol = current.forecast.condition;
    const spanConditionSymbol = createElement('span', undefined, 'condition symbol');
    spanConditionSymbol.innerHTML = symbols[conditionSymbol];

    divForecasts.appendChild(spanConditionSymbol);
    currentDiv.appendChild(divForecasts);

    const span = createElement('span', undefined, 'condition');
    const spanCity = createElement('span', `${current.name}`, 'forecast-data');
    const spanHighLow = createElement('span', undefined, 'forecast-data');
    spanHighLow.innerHTML = `${current.forecast.low}${symbols.Degree}/${current.forecast.high}${symbols.Degree}`;
    const spanCondition = createElement('span', `${current.forecast.condition}`, 'forecast-data');

    [spanCity, spanHighLow, spanCondition].map((el) => span.appendChild(el));
    divForecasts.appendChild(span);

    const divForecastInfo = createElement('div', undefined, 'forecast-info');
    upcomingDiv.appendChild(divForecastInfo);

    for (let index = 0; index < upcoming.forecast.length; index++) {
        createSpan(upcoming, index, symbols).map(e => divForecastInfo.appendChild(e))
    }
}


async function getCode(cityName) {
    const url = 'http://localhost:3030/jsonstore/forecaster/locations';
    const response = await fetch(url);
    const data = await response.json();
    
    return data.find(x => x.name.toLowerCase() == cityName.toLowerCase()).code;
}


async function getCurrent(code) {
    const url = 'http://localhost:3030/jsonstore/forecaster/today/' + code;
    const response = await fetch(url);
    const data = await response.json();
    
    return data;
}

async function getUpcoming(code) {
    const url = 'http://localhost:3030/jsonstore/forecaster/upcoming/' + code;
    const response = await fetch(url);
    const data = await response.json();
    
    return data;
}
function createElement(type, text, attributes) {
    const result = document.createElement(type);
    if (text) {
        result.textContent = text;
    }
    if (attributes) {
        result.className = attributes;
    }

    return result;
}

function createSpan(upcoming, index, symbols) {
    const symbol = upcoming.forecast[index].condition;
    const low = upcoming.forecast[index].low;
    const high = upcoming.forecast[index].high;
    
    const spanSymbol = createElement('span', undefined, 'symbol');
    spanSymbol.innerHTML = symbols[symbol]
    const highLow = createElement('span', undefined, 'forecast-data');
    highLow.innerHTML = `${low}${symbols.Degree}/${high}${symbols.Degree}`
    const condition = createElement('span', symbol, 'forecast-data');
    
    return [spanSymbol, highLow, condition]
}