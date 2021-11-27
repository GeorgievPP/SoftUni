const baseUrl = "http://localhost:3030/jsonstore";

export const getAll = async () => {
    let response = await fetch(`${baseUrl}/pets`);

    let pets = response.json();

    return pets;
};