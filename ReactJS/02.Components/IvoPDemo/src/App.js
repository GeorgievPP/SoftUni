import './App.css';
import Heading from './components/Heading';
import BookList from './components/BookList';
import Counter from './components/Counter';

const booksData = [
  {title: 'Harry Potter', description: 'Wizards and stuff'},
  {title: 'Programming with JS', description: 'Guide to programmer'},
  {title: 'The Bible', description: 'Most important book'},
  {title: 'Chronicles of Narnia', description: 'Adventure'},
];
function App() {
  return (
    <div className="site-wrapper">
      <Heading text='Our Custom Library' />

      <Counter />

      <BookList books={booksData} />
    </div>
  );
}

export default App;
