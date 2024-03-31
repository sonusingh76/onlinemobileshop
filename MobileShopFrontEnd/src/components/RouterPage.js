import React from  'react';
import {BrowserRouter as Router, Routes, Route} from 'react-router-dom';

import AdminDashboard from './admin/AdminDashboard';
import ProductManagement from './admin/ProductManagement';
import Orders from './admin/Orders';

import Login from './Login';
import Registration from './Registration';

import ProductsDisplay from './users/ProductsDisplay';
import Dashboard from './users/Dashboard';

export default function RouterPage(){
    
    return(
        <Router>
            <Routes>
                {/* Login - Registration */}
                <Route exact path='/' element={ <Login /> } />
                <Route path='/registration' element={ <Registration /> } />
                
                {/* Admin Pages */}
                <Route path='/admindashboard' element={ <AdminDashboard /> } />
                <Route path='/myorders' element={ <Orders /> } />
                <Route path='/productmanagement' element={ <ProductManagement /> } />

                {/* Users Pages */}
                <Route path='/dashboard' element={ <Dashboard /> } />                
                <Route path='/products' element={ <ProductsDisplay /> } />
                
            </Routes>
        </Router>
    )
}