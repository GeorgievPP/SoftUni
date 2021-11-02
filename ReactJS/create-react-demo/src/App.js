import Header from './components/Header';
import Footer from './components/Footer';
import Lorem from './components/Lorem';
import Clock from './components/Clock';
import Counters from './components/Counters';


import './App.css';
import Welcome from './components/Welcome';
import Clock2 from './components/Clock2';

function App() {
    return (
        <div className="site-wrapper">
            <Header>Hello React Prop Children </Header>
            <Header>Second React Prop Children </Header>


            <main>
                <Clock2 />
                <Counters />

                <Lorem />
            </main>

            <Footer />
        </div>

    );
}

export default App;
