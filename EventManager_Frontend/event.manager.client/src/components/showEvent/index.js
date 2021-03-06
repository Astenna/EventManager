import React from 'react';
import axios from 'axios';
import moment from 'moment';
import {withRouter, Link} from 'react-router-dom'
import {ControlLabel, Col, PageHeader, Badge, Row, Grid, Table, Button} from 'react-bootstrap';

const pathEvent = '/event/';

class ShowEvent extends React.Component {
    constructor()
    {
        super();
        this.state = {
            event: [],
        };
    }

    componentDidMount() {
        this.getEvent();
    }

    getEvent() {
        axios.get(pathEvent + this.props.match.params.id)
            .then((response) => {
                console.log(response.data)
                this.setState({
                    event: response.data
                });
            })
            .catch(function (error) {
                console.log("err2");
                console.log(error);
            });
    }

    addUser() {
        window.confirm("Zapisano na wydarzenie!");
    }

    renderTable() {               
        if(this.state.event.lectures !== 0 && this.state.event.lectures !== undefined) {
            if(this.state.event.lectures.length !== 0) {
                return this.state.event.lectures.map((option) => (
                    <tr key={option.id}>
                        <td>{option.name}</td>
                        <td>{option.description}</td>
                        <td>{this.parseDate(option.startDate)}</td>
                        <td width="10%"><Link to={"/NewReview/" + option.id}>
                            <Button className="btn btn-primary center-block">Oceń</Button>
                        </Link></td>
                        <td width="10%"><Button onClick={this.addUser}
                                                className="btn btn-primary center-block">Dołącz</Button></td>
                    </tr>
                ));
            }
            else{
                return <tr>
                    <td></td>
                    <td>To wydarzenie nia posiada wykładów</td>
                    <td></td>
                </tr>
            }
        }
    }

    parseDate(date)
    {
        return (
            moment(date).format("DD.MM.YYYY") + "  " + moment(date).format("HH:mm")
        )
    }

    render() {
        return (
        <Col>
            <Col>
                <Col sm={1}></Col>
                <Col sm={10}> 
                    <PageHeader > {this.state.event.name} </PageHeader> 
                </Col>
            </Col>
            <Grid sm={10}>
                <Col sm={4}>
                    <Row>
                    <br></br>
                    <Col componentClass={ControlLabel} sm={5}> Liczba uczestników </Col>
                    <Col componentClass={Badge} sm={5}>{this.state.event.participantNumber} </Col>
                    </Row>

                    <Row>                    
                    <Col componentClass={ControlLabel} sm={5}> Data rozpoczęcia </Col>
                    <Col componentClass={Badge} sm={5}>{this.parseDate(this.state.event.startDate)} </Col>
                    </Row>

                    <Row>
                    <Col componentClass={ControlLabel} sm={5}> Data zakończenia </Col>
                    <Col componentClass={Badge} sm={5}>{this.parseDate(this.state.event.endDate)} </Col>
                    </Row>

                    <Row>
                    <Col componentClass={ControlLabel} sm={10}> Opis </Col>
                    </Row>

                    <Row>
                            <div style={{background:"gray",borderRadius:"15px",padding:"10px",color:"white"}}>
                                {this.state.event.description}
                            </div>
                    </Row>
                    <Row>
                    <br></br>
                    <Col sm={5}>
                    <Link to={"/NewLecture/" + this.props.match.params.id} style={{color: 'black'}}>
                    <Button className="btn btn-primary"> Dodaj wykład do wydarzenia </Button>
                    </Link>
                    </Col>
                    </Row>
                </Col>
                <Col sm={8}>
                <Table>
                    <thead>
                        <tr>
                        <th width="30%">Nazwa</th>
                        <th width="40%">Opis</th>
                        <th width="30%">Data rozpoczęcia</th>
                        <th width="10%"></th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.renderTable()===null ? "To wydarzenie nia posiada wykładów" : this.renderTable() }
                    </tbody>
                </Table>
                </Col>
            </Grid>
        </Col>
        );
    }
}

export default withRouter(ShowEvent);
