import React from 'react';
import Navbar from '../Components/Navbar';
import Footer from '../Components/Footer';
// import './Home.css';

const Home = () => (
    <>
        <Navbar />
        <div className="container">
            <h1>Welcome to GatherOrg</h1>
            <p>Connecting volunteers with those who need help.</p>
        </div>
        <Footer />
    </>
);

export default Home;