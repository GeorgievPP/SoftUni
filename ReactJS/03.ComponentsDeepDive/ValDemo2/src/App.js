import './App.css';
import ClassComp from './components/ClassComp';
import Heading from './components/Heading';

const booksData = [
  {title: 'Harry Potter', description: 'Wizards and stuff'},
  {title: 'Programming with JS', description: 'Guide to programmer'},
  {title: 'The Bible', description: 'Most important book'},
  {title: 'Chronicles of Narnia', description: 'Adventure'},
];
function App() {
  return (
    <div className="site-wrapper">
      <Heading text="Heading" />

     <ClassComp />

    </div>
  );
}

export default App;

/**
 * 
 * <ValCounter counter={0} />
      <ValCounter counter={0} />
      <ValCounter counter={0} />

 */