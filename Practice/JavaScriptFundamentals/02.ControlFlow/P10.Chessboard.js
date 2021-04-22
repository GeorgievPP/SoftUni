function chessboard([number]) {
    number = Number(number);

    let html = '<div class="chessboard>\n';

    for(let i = 0; i < number; i++) {
        html += '\t<div>\n';

        for(let j = 0; j < number; j++){
            let color = (i + j) % 2 == 0 ? "black" : "white";
            html += `\t\<span class="${color}"></span>\n`;
        }

        html += '\t</div>\n';
    }

    html += '</div>';

    console.log(html);
}

//chessboard([3]);

