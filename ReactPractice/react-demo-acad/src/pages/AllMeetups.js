const DUMMY_DATA = [
    {
        id: 'm1',
        title: 'This is a first meetup',
        image: 'https://www.researchgate.net/profile/Aneta-Vasileva/publication/320345907/figure/fig6/AS:631629785620499@1527603684301/15-View-from-the-Varna-Municipality-Hall-towards-Osmi-Primorski-Polk-Boulevard-The.png',
        address: 'Varna 5',
        description: 'This is a first Varna Meetup'
    },
    {
        id: 'm2',
        title: 'This is a SECOND meetup',
        image: 'https://www.researchgate.net/profile/Aneta-Vasileva/publhttps://plovdivcitycard.com/wp-content/uploads/2019/01/The-Best-Viewpoints-In-Plovdiv-5-Spots-For-Amazing-Selfies.jpg   ication/320345907/figure/fig6/AS:631629785620499@1527603684301/15-View-from-the-Varna-Municipality-Hall-towards-Osmi-Primorski-Polk-Boulevard-The.png',
        address: 'Varna 5',
        description: 'This is a first Plovdiv Meetup'
    }
]


function AllMeetupsPage() {
    return <section>
        <h1>All meetups</h1>
        <ul>
            {DUMMY_DATA.map((meetup) => {
                return <li key={meetup.id}>{meetup.title}</li>
            })}
        </ul>
    </section>
}

export default AllMeetupsPage;