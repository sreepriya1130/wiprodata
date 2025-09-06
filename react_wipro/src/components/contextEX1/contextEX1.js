import React, {Component} from 'react';
import './contextEX1.scss'
// import { connect } from "react-redux";
// import { bindActionCreators } from "redux";
// import * as contextEX1Actions from "../../store/contextEX1/actions";
export default class contextEX1 extends Component {
    // constructor(props) {
    //     super(props);
    //     this.state = {};
    // }
    render() {
      return <div className="component-context-e-x1">Hello! component contextEX1</div>;
    }
  }
// export default connect(
//     ({ contextEX1 }) => ({ ...contextEX1 }),
//     dispatch => bindActionCreators({ ...contextEX1Actions }, dispatch)
//   )( contextEX1 );