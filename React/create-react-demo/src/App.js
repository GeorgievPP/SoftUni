import Header from './components/Header';
import Footer from './components/Footer';
import Lorem from './components/Lorem';

import './App.css';

function App() {
    return (
        <div className="site-wrapper">
            <Header>Hello React Prop Children </Header>
            <Header>Second React Prop Children </Header>


            <main>
                <Lorem />
                <Lorem />
                <Lorem />
            </main>

            <Footer />
        </div>

    );
}

export default App;
