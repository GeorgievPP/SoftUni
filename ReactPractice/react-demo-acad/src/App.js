import { Routes, Route } from "react-router-dom";

import AllMeetupsPage from "./pages/AllMeetups";
import NewMeetupsPage from "./pages/NewMeetups";
import FavoritesPage from "./pages/Favorites";
import MainNavigation from './components/layouts/MainNavigation'

function App() {
  return (
    <div>
      <MainNavigation />
      <Routes>
        <Route path="/" element={<AllMeetupsPage />}/>
        <Route path="/new-meetup" element={<NewMeetupsPage />}/>
        <Route path="/favorites" element={<FavoritesPage />}/>
      </Routes>
    </div>
  );
}

export default App;
