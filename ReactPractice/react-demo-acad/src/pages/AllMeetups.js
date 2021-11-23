import MeetupList from "../components/meetups/MeetupList";

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
        image: 'https://www.researchgate.net/profile/Aneta-Vasileva/publication/320345907/figure/fig6/AS:631629785620499@1527603684301/15-View-from-the-Varna-Municipality-Hall-towards-Osmi-Primorski-Polk-Boulevard-The.png',
        address: 'Varna 5',
        description: 'This is a first Plovdiv Meetup'
    }
]


function AllMeetupsPage() {
    return <section>
        <h1>All meetups</h1>
        <MeetupList meetups={DUMMY_DATA} />
    </section>
}

export default AllMeetupsPage;