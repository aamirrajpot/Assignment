import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import  {Home}  from './components/Home';
import   {Courses } from './components/Courses';
import {AddStudent} from './components/AddStudent';
import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/courses' component={Courses} />
        <Route path='/add-student' component={AddStudent} />
      </Layout>
    );
  }
}
