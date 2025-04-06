import React, { useState } from 'react';
import './VolunteerForm.css';

const VolunteerForm = () => {
    const [formData, setFormData] = useState({
        occupation: '',
        knowledge: '',
        experience: '',
        limitations: '',
        availability: 'in-person',
    });

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData({ ...formData, [name]: value });
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        // Submit form data to API
    };

    return (
        <form className="volunteer-form" onSubmit={handleSubmit}>
            <h2>Register as a Volunteer</h2>
            <div className="form-group">
                <label>Occupation</label>
                <input type="text" name="occupation" value={formData.occupation} onChange={handleChange} required />
            </div>
            <div className="form-group">
                <label>Knowledge</label>
                <input type="text" name="knowledge" value={formData.knowledge} onChange={handleChange} required />
            </div>
            <div className="form-group">
                <label>Experience</label>
                <input type="text" name="experience" value={formData.experience} onChange={handleChange} required />
            </div>
            <div className="form-group">
                <label>Limitations</label>
                <input type="text" name="limitations" value={formData.limitations} onChange={handleChange} />
            </div>
            <div className="form-group">
                <label>Availability</label>
                <select name="availability" value={formData.availability} onChange={handleChange}>
                    <option value="in-person">In-Person</option>
                    <option value="on-phone">On Phone</option>
                    <option value="online">Online</option>
                </select>
            </div>
            <button type="submit" className="button">Register</button>
        </form>
    );
};

export default VolunteerForm;