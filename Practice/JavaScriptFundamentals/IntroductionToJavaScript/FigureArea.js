function figureArea([w, h, W, H]){
    let figOneArea = Number(w) * Number(h);
    let figTwoArea = Number(W) * Number(H);
    let commonArea = Math.min(Number(w), Number(W)) * Math.min(Number(h), Number(H));

    let figureArea = figOneArea + figTwoArea - commonArea;
    console.log(figureArea);
    return figureArea;
}
figureArea(['2', '4', '5', '3']);