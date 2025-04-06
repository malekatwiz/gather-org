import React from 'react';
// import './Navbar.css';

const Navbar = () => (
    <nav className="navbar">
        <div className="container">
            <h1>GatherOrg</h1>
            <ul>
                <li><a href="/">Home</a></li>
                {/* <li><a href="/register-volunteer">Register as Volunteer</a></li>
                <li><a href="/register-service-seeker">Register as Service Seeker</a></li>
                <li><a href="/volunteers">Volunteers</a></li>
                <li><a href="/service-seekers">Service Seekers</a></li> */}
            </ul>
        </div>
    </nav>
);

export default Navbar;