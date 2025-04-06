import React from 'react';
import Navbar from '../Components/Navbar';
import Footer from '../Components/Footer';
import VolunteerForm from '../Components/VolunteerForm';
import './RegisterVolunteer.css';

const RegisterVolunteer = () => (
    <>
        <Navbar />
        <div className="container">
            <VolunteerForm />
        </div>
        <Footer />
    </>
);

export default RegisterVolunteer;