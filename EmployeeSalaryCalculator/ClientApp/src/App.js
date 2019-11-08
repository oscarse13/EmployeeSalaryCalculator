import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { EmployeeSalaryCalculator } from './components/EmployeeSalaryCalculator';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
            <Route exact path='/' component={EmployeeSalaryCalculator} />
            <Route path='/EmployeeSalaryCalculator' component={EmployeeSalaryCalculator} />
      </Layout>
    );
  }
}
