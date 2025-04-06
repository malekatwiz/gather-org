import React from 'react';
import './App.css';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Home from './Pages/Home/Home';
// import RegisterVolunteer from './Pages/RegisterVolunteer';
// import RegisterServiceSeeker from './Pages/RegisterServiceSeeker';
// import VolunteerList from './Pages/VolunteerList';
// import ServiceSeekerList from './Pages/ServiceSeekerList';

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Home />} />
        {/* <Route path="/register-volunteer" element={<RegisterVolunteer />} />
        <Route path="/register-service-seeker" element={<RegisterServiceSeeker />} />
        <Route path="/volunteers" element={<VolunteerList />} />
        <Route path="/service-seekers" element={<ServiceSeekerList />} /> */}
      </Routes>
    </Router>
  );
}

export default App;