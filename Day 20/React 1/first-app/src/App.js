import logo from './logo.svg';
import './App.css';
import AddProduct from './components/AddProduct';
import Products from './components/Products';

function App() {
  return (
    <div className="container text-center">
      <div className='row'>
      <div className='col'>
        <Products/>
      </div>
      <div className="col">
        <AddProduct/>
      </div>
      </div>
    </div>
  );
}

export default App;