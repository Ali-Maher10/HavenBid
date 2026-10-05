
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import HouseList from '../house/HouseList'
import HouseDetail from '../house/HouseDetail'
import './App.css'
import Header from './Header'
import HouseAdd from '../house/HouseAdd'
import HouseEdit from '../house/HouseEdit'

function App() {
  
  return (
    <BrowserRouter>
      <Header subtitle="Providing houses all over the world"/>
      <main className="container page">
        <Routes>
          <Route path="/" element={<HouseList/>} ></Route>
          <Route path="/house/:id" element={<HouseDetail/>} ></Route>
          <Route path="/house/add" element={<HouseAdd/>} ></Route>
          <Route path="/house/edit/:id" element={<HouseEdit/>} ></Route>
        </Routes>
      </main>
    </BrowserRouter>
      
  );
}

export default App
